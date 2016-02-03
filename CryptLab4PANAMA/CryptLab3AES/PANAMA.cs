using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptLab4PANAMA
{


    public class Panama
    {
        int[] state = new int[17];
        int[,] buffer = new int[32, 8];

        /// <summary>
        /// Сброс буферов
        /// </summary>
        void Reset()
        {
            Array.Clear(state, 0, state.Length);
            Array.Clear(buffer, 0, buffer.Length);
        }


        /// <summary>
        /// Операция внесения данных в буферы
        /// </summary>
        /// <param name="input"></param>
        void Push(int[] input)
        {
            //сдвиг каскадов кроме 1-24
            for (int i = 1; i < 25; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buffer[i, j] = buffer[i - 1, j];
                }
            }
            //сдвиг каскадов кроме 26-31
            for (int i = 26; i < 32; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buffer[i, j] = buffer[i - 1, j];
                }
            }
            //заполнение 0 каскада
            for (int i = 0; i < 8; i++)
            {
                buffer[0, i] = buffer[31, i] ^ input[i];
            }
            //заполнение 25 каскада
            for (int i = 0; i < 8; i++)
            {
                buffer[25, i] = buffer[24, i] ^ buffer[31, (i + 2) % 8];
            }

            //нелинейность
            int[] r = new int[17];
            for (int i = 0; i < 17; i++)
            {
                r[i] = state[i] ^ (state[(i + 1) % 17] | ~state[(i + 2) % 17]);
            }

            //дисперсия
            int[] s = new int[17];
            for (int i = 0; i < 17; i++)
            {
                s[i] = RotateLeft(r[(7 * i) % 17], ((i * (i + 1) / 2) % 32));
            }

            //диффузия
            int[] t = new int[17];
            for (int i = 0; i < 17; i++)
            {
                t[i] = s[i] ^ s[(i + 1) % 17] ^ s[(i + 4) % 17];
            }

            //добавление входных данных
            state[0] = t[0] ^ 0x00000001;
            for (int i = 0; i < 7; i++)
            {
                state[(i + 9) % 17] = t[(i + 1) % 17] ^ buffer[16, i];
                state[(i + 1) % 17] = t[(i + 1) % 17] ^ input[i];
            }


        }


        /// <summary>
        /// Операция получения результатов из буферов
        /// </summary>
        /// <returns></returns>
        int[] Pull()
        {
            //сдвиг каскадов кроме 1-24
            for (int i = 1; i < 25; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buffer[i, j] = buffer[i - 1, j];
                }
            }
            //сдвиг каскадов кроме 26-31
            for (int i = 26; i < 32; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buffer[i, j] = buffer[i - 1, j];
                }
            }
            //заполнение 0 каскада
            for (int i = 0; i < 8; i++)
            {
                buffer[0, i] = buffer[31, i] ^ state[i + 1];
            }
            //заполнение 25 каскада
            for (int i = 0; i < 8; i++)
            {
                buffer[25, i] = buffer[24, i] ^ buffer[31, (i + 2) % 8];
            }

            //нелинейность
            int[] r = new int[17];
            for (int i = 0; i < 17; i++)
            {
                r[i] = state[i] ^ (state[(i + 1) % 17] | ~state[(i + 2) % 17]);
            }

            //дисперсия
            int[] s = new int[17];
            for (int i = 0; i < 17; i++)
            {
                s[i] = RotateLeft(r[(7 * i) % 17], ((i * (i + 1) / 2) % 32));
            }

            //диффузия
            int[] t = new int[17];
            for (int i = 0; i < 17; i++)
            {
                t[i] = s[i] ^ s[(i + 1) % 17] ^ s[(i + 4) % 17];
            }

            //добавление входных данных
            state[0] = t[0] ^ 0x00000001;
            for (int i = 0; i < 7; i++)
            {
                state[(i + 9) % 17] = t[(i + 1) % 17] ^ buffer[16, i];
                state[(i + 1) % 17] = t[(i + 1) % 17] ^ buffer[4, i];
            }

            //возврат результата
            int[] z = new int[8];
            for (int i = 0; i < 8; i++)
            {
                z[i] = state[i + 9];
            }

            return z;
        }


        /// <summary>
        /// Перемешивание данных в буферах
        /// </summary>
        void BlankPull()
        {
            Pull();
        }


        /// <summary>
        /// Инициализация поточного шифра
        /// </summary>
        /// <param name="key"></param>
        /// <param name="param"></param>
        public void InitCipher(int[] key, int[] param)
        {
            Reset();

            //ввод ключа
            Push(key.Take(8).ToArray());

            //ввод параметра
            Push(param.Take(8).ToArray());

            //перемешивание ключа и параметра
            for (int i = 0; i < 32; i++)
            {
                BlankPull();
            }
        }


        /// <summary>
        /// Шифрование, расшифрование
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int[] EncryptDecrypt(int[] data)
        {
            //создаем ключ как последовательность случайных чисел, полученных из алгоритма
            int[] key = new int[data.Length + (8 - data.Length % 8)];

            for (int i = 0; i < key.Length / 8; i++)
            {
                Array.Copy(Pull(), 0, key, i * 8, 8);
            }

            //складываем с данными
            int[] result = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = data[i] ^ key[i];
            }
            return result;
        }


        /// <summary>
        /// Получение хэша данных
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int[] Hash(int[] data)
        {
            int[] addedData;

            //если последовательность не кратна 32 байтам, то добавляем в конец бит 1 и нули
            if (data.Length % 8 != 0)
            {
                addedData = new int[data.Length + (8 - data.Length % 8)];
            }
            else
            {
                addedData = new int[data.Length + 8];
            }
            addedData[data.Length] = 1;

            Array.Copy(data, addedData, data.Length);

            Reset();



            //вводим данные
            for (int i = 0; i < addedData.Length / 8; i++)
            {
                Push(addedData.Skip(i * 8).Take(8).ToArray());
            }


            //перемешивание данных
            for (int i = 0; i < 32; i++)
            {
                BlankPull();
            }

            return Pull();


        }


        /// <summary>
        /// Циклический поворот битов влево
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static int RotateLeft(int value, int count)
        {

            return (value << count) | (value >> (32 - count));
        }


        /// <summary>
        /// Циклический поворот битов вправо
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static int RotateRight(int value, int count)
        {
            return (value >> count) | (value << (32 - count));
        }



        /// <summary>
        /// Преобразование массива целых чисел в байтовый
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] IntArrToByteArr(int[] data)
        {
            byte[] result = new byte[data.Length * 4];

            for (int i = 0; i < data.Length; i++)
            {
                Array.Copy(BitConverter.GetBytes(data[i]), 0, result, i * 4, 4);
            }

            return result;
        }


        /// <summary>
        /// Преобразование массива байт в массив целых чисел
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int[] ByteArrToIntArr(byte[] data)
        {
            byte[] temp;
            if (data.Length%4 != 0)
            {
                temp = new byte[data.Length + (4 - data.Length % 4)];
                Array.Copy(data, temp, data.Length);
            }
            else
            {
                temp = data;
            }

            int[] result = new int[temp.Length / 4];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = BitConverter.ToInt32(temp, i * 4);
            }

            return result;
        }

    }

}
