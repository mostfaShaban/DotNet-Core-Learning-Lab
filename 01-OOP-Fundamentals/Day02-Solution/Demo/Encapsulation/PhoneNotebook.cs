using System.Security.Cryptography;
using System.Xml.Linq;

namespace Demo.Encapsulation
{
	internal struct PhoneNotebook
	{
		#region Attributes 
		private string[]? names;
		private int[]? numbers;
		private int size;
		#endregion

		#region Constructors
		public PhoneNotebook(int NoteSize)
		{
			size = NoteSize;
			names = new string[size];
			numbers = new int[size];
		}
		#endregion

		#region Properties [Indexer]
		public int Size
		{
			// Read Only Property 
			get { return size; }
		}

		// 3. Indexer 
		// Is a Special Property [Named With Keyword This and Can Take Parameters]
		public int this[string Name]
		{
			get
			{
				if (names is not null && numbers is not null)
					for (int i = 0; i < names.Length; i++)
						if (Name == names[i])
							return numbers[i];
				return -1;
			}
			set
			{
				if (names is not null && numbers is not null)
					for (int i = 0; i < names.Length; i++)
					{
						if (Name == names[i])
							numbers[i] = value;
						return;
					}
			}
		}


		//public string this[int index]
		//{
		//	get
		//	{
		//		return $"Position => {index} :: Name => {names[index]} :: Number => {numbers[index]}";
		//	}
		//}

		#endregion

		#region Methods 

		public void AddPerson(int Position, string Name, int Number)
		{
			if (names is not null && numbers is not null)
			{
				if (Position < size)
				{
					names[Position] = Name;
					numbers[Position] = Number;
				}
			}
		}

        #endregion

        #region Setter - Getter 
        // indexer is a special property that can be used as getter and setter بديل ما نعمل دوال جت و سيت عادية
        // Getter 
        public int GetNumber(string name)
		{
			if (names is not null && numbers is not null)
			{
				for (int i = 0; i < names.Length; i++)
				{
					if (name == names[i])
						return numbers[i];
				}
			}
			return -1;
		}

		// Setter 
		public void SetNumber(string Name, int NewNumber)
		{
			if (names is not null && numbers is not null)
			{
				for (int i = 0; i < names.Length; i++)
				{
					if (Name == names[i])
						numbers[i] = NewNumber;
					//break;
					return;
				}
			}
		}

		#endregion

	}
}
