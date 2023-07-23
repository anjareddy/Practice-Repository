Singleton
	-> 0 or 1 instances at max.
	-> Singleton classes are created without parameters.
	-> Singleton is not thread safe by default.
	-> Supports Lazy instantiation.
	-> It has single private parameterless contructor.
	-> class has to be sealed, so that jit can directly make class to a of this class instead of going through virtual dispatch route.
	-> Singleton class that needs to be initialized with multiple parameters, have to use factory design patterns.
	-> Singleton can be serialized where as static class can't be serialized.

->Trasient
	->New instance everytime even within scoped
->Scoped
	-> One instance for scope and used during the scope of request. Ex: EF or HTTP request
->Singleton
	->Only one instance will be created and used throughout the lifetime of the application
