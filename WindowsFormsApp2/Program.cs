using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class NewProgram
    {
		RightTriangle[] rTriangles;
		Triangle[] triangles;

		  Random rand = new Random();

        public void taskTriangle(TextBox field, int N)
        {
            field.Text = "Все треугольники:\r\n";

            
            int maxS = 0;

			if(triangles == null)
			{
				triangles = new Triangle[N];
				for (int i = 0; i < N; i++)
				{
					float s1 = (float)rand.Next(15) + 1;
					float s2 = (float)rand.Next(15) + 1;
					float s3 = (float)rand.Next(15) + 1;

					while (!Triangle.exists(s1, s2, s3))
					{
						s1 = (float)rand.Next(15) + 1;
						s2 = (float)rand.Next(15) + 1;
						s3 = (float)rand.Next(15) + 1;
					}

					triangles[i] = new Triangle(s1, s2, s3);

					if (triangles[i].getSquare() > triangles[maxS].getSquare()) maxS = i;

					field.Text += "Треугольник №" + (i + 1) + "\r\n" + triangles[i].getInfo();
				}
			}
			else
			{
				for (int i = 0; i < N; i++)
				{
					if (triangles[i].getSquare() > triangles[maxS].getSquare()) maxS = i;
					field.Text += "Треугольник №" + (i + 1) + "\r\n" + triangles[i].getInfo();
				}
			}

          
            field.Text += "\r\nТреугольник с максимальной площадью:\r\n";
            field.Text += "Треугольник №" + (maxS + 1) + "\r\n" + triangles[maxS].getInfo();
        }

        public void taskRTriangle(TextBox field, int M)
        {
            int minH = 0;

			field.Text = "Все прямоугольные треугольники:\r\n";

			if (rTriangles == null)
			{
				rTriangles = new RightTriangle[M];
				for (int i = 0; i < M; i++)
				{
					float s1 = (float)rand.Next(15) + 1;
					float s2 = (float)rand.Next(15) + 1;

					rTriangles[i] = new RightTriangle(s1, s2);

					if (rTriangles[i].getHypotenuse() < rTriangles[minH].getHypotenuse()) minH = i;

					field.Text += "Треугольник №" + (i + 1) + "\r\n" + rTriangles[i].getInfo();
				}
			}
			else
			{
				for (int i = 0; i < M; i++)
				{
					if (rTriangles[i].getHypotenuse() < rTriangles[minH].getHypotenuse()) minH = i;
					field.Text += "Треугольник №" + (i + 1) + "\r\n" + rTriangles[i].getInfo();
				}
			}

         field.Text += "\r\nТреугольник с минимальной гипотенузой:\r\n";
         field.Text += "Треугольник №" + (minH + 1) + "\r\n" + rTriangles[minH].getInfo();
        }

		public void saveFile(String path, int choVpisat)
		{
			FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
			BinaryWriter writer = new BinaryWriter(fileStream);

			Triangle[] arr = choVpisat == 1 ? triangles : rTriangles;

			writer.Write(choVpisat);
			writer.Write(arr.Length);
			for(int i = 0; i < arr.Length; i++)
			{
				writer.Write((double)arr[i].a);
				writer.Write((double)arr[i].b);
				writer.Write((double)arr[i].c);
			}

			writer.Close();
			fileStream.Close();
		}

		public void loadFile(String path)
		{
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryReader reader = new BinaryReader(fileStream);

			int choProchest = reader.ReadInt32();
			int length = reader.ReadInt32();

			Triangle[] temp = new Triangle[length];

			int i = 0;
			while (fileStream.CanRead && i < length)
			{
				float a = (float)reader.ReadDouble();
				float b = (float)reader.ReadDouble();
				float c = (float)reader.ReadDouble();
				temp[i] = new Triangle(a,b,c);
				i++;
			}

			if (choProchest == 1) triangles = temp;
			else if (choProchest == 2)
			{
				RightTriangle[] temp2 = new RightTriangle[length];

				for(int j = 0; j < length; j++)
				{
					temp2[j] = new RightTriangle(temp[i].a, temp[i].b);
				}

				rTriangles = temp2;
			}
		}
	}
}

