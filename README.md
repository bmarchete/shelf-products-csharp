# shelf-products-csharp
A windows form application example

This example demonstrates how to create a windows form application using Entity Framework 6. 

The application allows to create n shelfs linked with their products. The form class that adds new shelfs was designed with singleton pattern,
and implements a observer pattern. This way, every time a shelf is added, all others forms that are registered like listeners can self-update.

The observer pattern was implemented using delegates.
