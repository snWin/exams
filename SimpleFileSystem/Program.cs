using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleFileSystem
{
	class SimpleFileSystem
	{
		private string rootDirectory;

		public SimpleFileSystem(string rootPath)
		{
			rootDirectory = rootPath;

			if (!Directory.Exists(rootDirectory))
			{
				Directory.CreateDirectory(rootDirectory);
			}
		}

		private string GetFullPath(string fileName)
		{
			return Path.Combine(rootDirectory, fileName);
		}

		public void CreateFile(string fileName)
		{
			string path = GetFullPath(fileName);

			if (File.Exists(path))
			{
				Console.WriteLine("File already exists.");
				return;
			}

			File.Create(path).Close();
			Console.WriteLine("File created successfully.");
		}

		public void WriteFile(string fileName, string content)
		{
			string path = GetFullPath(fileName);

			if (!File.Exists(path))
			{
				Console.WriteLine("File does not exist.");
				return;
			}

			File.WriteAllText(path, content);
			Console.WriteLine("Content written to file.");
		}

		public void ReadFile(string fileName)
		{
			string path = GetFullPath(fileName);

			if (!File.Exists(path))
			{
				Console.WriteLine("File does not exist.");
				return;
			}

			string content = File.ReadAllText(path);
			Console.WriteLine("File Content:");
			Console.WriteLine(content);
		}

		public void DeleteFile(string fileName)
		{
			string path = GetFullPath(fileName);

			if (!File.Exists(path))
			{
				Console.WriteLine("File does not exist.");
				return;
			}

			File.Delete(path);
			Console.WriteLine("File deleted.");
		}

		public void ListFiles()
		{
			string[] files = Directory.GetFiles(rootDirectory);

			if (files.Length == 0)
			{
				Console.WriteLine("No files found.");
				return;
			}

			Console.WriteLine("Files:");
			foreach (string file in files)
			{
				Console.WriteLine(Path.GetFileName(file));
			}
		}
	}

	internal class Program
	{
		//static void Main(string[] args)
		//{
		//}
		static void Main()
		{
			string root = Path.Combine(Environment.CurrentDirectory, "MyFileSystem"); // will create in bin\Debug
			//string root = Path.Combine(@"D:\exam\exams", "MyFileCollection");

			SimpleFileSystem fs = new SimpleFileSystem(root);

			while (true)
			{
				Console.WriteLine("\n=== Simple File System ===");
				Console.WriteLine("1. Create File");
				Console.WriteLine("2. Write File");
				Console.WriteLine("3. Read File");
				Console.WriteLine("4. Delete File");
				Console.WriteLine("5. List Files");
				Console.WriteLine("6. Exit");
				Console.Write("Choose option: ");

				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						Console.Write("File name: ");
						fs.CreateFile(Console.ReadLine() + ".txt");
						break;

					case "2":
						Console.Write("File name: ");
						string writeName = Console.ReadLine();
						Console.Write("Content: ");
						string content = Console.ReadLine();
						fs.WriteFile(writeName, content);
						break;

					case "3":
						Console.Write("File name: ");
						fs.ReadFile(Console.ReadLine());
						break;

					case "4":
						Console.Write("File name: ");
						fs.DeleteFile(Console.ReadLine());
						break;

					case "5":
						fs.ListFiles();
						break;

					case "6":
						return;

					default:
						Console.WriteLine("Invalid option.");
						break;
				}
			}
		}
	}
}
