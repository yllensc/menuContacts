//Agregar entradaMostrar todas las entradasMarcar entrada como importanteEliminar entrada Salir
int menuOption = 0;

//list of contacts 
List<Contact> ContactList = new List<Contact>();

do
{
    menuOption = showMainMenu();
    if ((Menu)menuOption == Menu.Add)
    {
        AddContact();
    }
    else if ((Menu)menuOption == Menu.List)
    {
        ShowContacts();
    }
    else if ((Menu)menuOption == Menu.MarkImportant)
    {
        MarkContactImportant();
    }
    else if ((Menu)menuOption == Menu.Delete)
    {
        DeleteContact();
    }
    else if ((Menu)menuOption == Menu.Exit)
    {
        Console.WriteLine("Bye,bye");
    }
    else {
        Console.WriteLine("No tenemos esta opción, revisa el menú");
    }

} while ((Menu)menuOption != Menu.Exit);

int showMainMenu(){
    Console.WriteLine("\n-----------AGENDA TELEFÓNICA------------");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Agregar entrada");
    Console.WriteLine("2. Mostrar entradas");
    Console.WriteLine("3. Marcar entrada importante");
    Console.WriteLine("4. Eliminar entrada");
    Console.WriteLine("5. Salir");
    Console.ResetColor();

    // Read option
    string optionMenu = Console.ReadLine();
    return Convert.ToInt32(optionMenu);
}

void AddContact()
{
    try
    {
        Console.WriteLine("Ingrese el nombre del contacto: ");
        string nameContact = Console.ReadLine();

        Console.WriteLine("Ingrese el teléfono del contacto: ");
        int telContact = Convert.ToInt32(Console.ReadLine());

        if (!string.IsNullOrEmpty(nameContact) && telContact > 0)
        {
            ContactList.Add(new Contact() { Name = nameContact, Telephone = telContact, MarkImportant = "📱"});
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Contacto registrado correctamente");
            Console.ResetColor();
        
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Los datos del contacto no están completos.");
            Console.ResetColor();
        }
    }
    catch (Exception)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ha ocurrido un error al intentar ingresar el contacto, ups.");
        Console.ResetColor();
    }
}

bool ShowContacts(){
    if (ContactList?.Count > 0){
        ListContacts();
        return true;
    }
    else{
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("No tienes contactos todavía, haz amigos jaja");
        Console.ResetColor();
        return false;
    }
}

void ListContacts(){
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("#- Nombre - Teléfono - Favoritos\n");
    var indexContact = 0;
    ContactList.ForEach(contact => Console.WriteLine($"{++indexContact}.{contact.Name} - {contact.Telephone} - {contact.MarkImportant}"));

    Console.WriteLine("----------------------------------------");

}

void MarkContactImportant(){
    try
    {
        
        // Show current contacts
        if(ShowContacts()){
        Console.WriteLine("Ingrese el número del contacto para agregar a favoritos: ");
        string contactIndex = Console.ReadLine();
        // position to mark
        int indexToUpdate = Convert.ToInt32(contactIndex) - 1;

        if (indexToUpdate <= ContactList.Count - 1 && indexToUpdate >= 0)
        {
            if ((indexToUpdate > -1) || (ContactList.Count > 0))
            {
                Contact contactFavorite = ContactList[indexToUpdate];
                contactFavorite.MarkImportant = "⭐";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{contactFavorite.Name} fue agregad@ a favoritos");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El número del contacto seleccionado no es válido.");
            Console.ResetColor();
        }
        }
    }
    catch (Exception)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ha ocurrido un error al actualizar el contacto.");
        Console.ResetColor();
    }
}

void DeleteContact(){
    try
    {
        
        // Show current contacts
        if(ShowContacts()){
        Console.WriteLine("Ingrese el número del contacto a eliminar: ");
        string contactIndex = Console.ReadLine();
        // position to delete
        int indexToRemove = Convert.ToInt32(contactIndex) - 1;

        if (indexToRemove <= ContactList.Count - 1 && indexToRemove >= 0)
        {
            if ((indexToRemove > -1) || (ContactList.Count > 0))
            {
                Contact contactToRemove = ContactList[indexToRemove];
                ContactList.RemoveAt(indexToRemove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Contacto '{contactToRemove.Name}' eliminado");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El número del contacto seleccionado no es válido.");
            Console.ResetColor();
        }
        }
    }
    catch (Exception)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ha ocurrido un error al eliminar el contacto.");
        Console.ResetColor();
    }
}
public enum Menu{
    Add = 1,
    List = 2,
    MarkImportant = 3,
    Delete = 4,
    Exit = 5,
}

public class Contact {
    public string? Name;
    public int Telephone;
    public string? MarkImportant;
}

    