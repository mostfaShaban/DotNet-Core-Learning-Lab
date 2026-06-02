namespace Demo.UserDefined_Datatypes
{
	/// What You Can Write Inside?
	/// 1. Class
	/// 2. Struct
	/// 3. Interface
	/// 4. Enum

	///Access Modifier Allowed Inside ?
    ///1. Internal[Default]
    ///2. Public

	internal class MyClass
	{
		/// What You Can Write Inside ?
		/// 1. Attributes [Fields] => Member Variable  
		int myAttribute ;  // Attribute With Private Access Modifier [Default]
		/// 2. Functions [Constructor , Getter Setter , Method]
		void MyFunction() // Method  With Private Access Modifier [Default]
		{

		}
		/// 3. Properties [Full Property , Automatic Property , Indexer]
	    int MyProperty { get; set; } // Property With Private Access Modifier [Default]
		/// 4. Events

        ///Access Modifier Allowed Inside?
        ///Private
        ///Private Protected
        ///Protected
        ///Internal
        ///Protected Internal
        ///Public

	}
}
