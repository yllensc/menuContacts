//Agregar entradaMostrar todas las entradasMarcar entrada como importanteEliminar entrada Salir
using System.Collections.Generic;
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
    else if ((Menu)menuOption == Menu.List){
        //ShowContacts();
    }
    else if ((Menu)menuOption == Menu.MarkImportant){
        //MarkContactImportant();
    }
    else if ((Menu)menuOption == Menu.Delete){
        //DeleteContact();
    }

} while ((Menu)menuOption != Menu.Exit);

int showMainMenu(){
    Console.WriteLine("----------------AGENDA TELEFÓNICA----------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Agregar entrada");
    Console.WriteLine("2. Mostrar entradas");
    Console.WriteLine("3. Marcar entrada importante");
    Console.WriteLine("4. Eliminar entrada");
    Console.WriteLine("5. Salir");

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
            Console.WriteLine($"Contacto registrado correctamente");
            foreach (var aPart in ContactList)
        {
            Console.WriteLine(aPart.MarkImportant);
        }
        }
        else
        {
            Console.WriteLine("Los datos del contacto no están completos.");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al intentar ingresar el contacto, ups.");
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

    