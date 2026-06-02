namespace Demo.UserDefined_Datatypes
{
	internal struct MyStruct
	{
		/// What You Can Write Inside ?
		/// 1. Attributes [Fields] => Member Variable  
		public int myAttribute;  // Attribute With public Access Modifier 
		/// 2. Functions [Constructor , Getter Setter , Method]
		internal void MyFunction() // Method  With internal Access Modifier
		{

		}
		/// 3. Properties [Full Property , Automatic Property , Indexer]
		 int MyProperty { get; set; } // Property With Private Access Modifier [Default]
		/// 4. Events

        ///Access Modifier Allowed Inside?
        ///Private
        ///Internal
        ///Public

	}
}
