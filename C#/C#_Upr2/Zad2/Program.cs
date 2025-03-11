using System.Text.RegularExpressions;
using System.Xml.Linq;
using Zad2;

var fileContent = File.ReadAllText("input-02.txt");

var nameRegex = new Regex(@"[А-Яа-я]+", RegexOptions.Multiline);
var idRegex = new Regex(@"\b\d{6}\b");
var phoneRegex = new Regex(@"\+395 \d{3} \d{2} \d{2}");

var names = new Queue<string>();
var ids = new Queue<string>();
var phones = new Queue<string>();

foreach (Match match in phoneRegex.Matches(fileContent))
    phones.Enqueue(match.Value.Trim());

foreach (Match match in idRegex.Matches(fileContent))
    ids.Enqueue(match.Value);

foreach (Match match in nameRegex.Matches(fileContent))
    names.Enqueue(match.Value);

var contacts = new List<Contact>();

while (names.Count > 0 || ids.Count > 0 || phones.Count > 0)
{
    var contact = new Contact();

    if (names.Count > 0)
        contact.Name = names.Dequeue();

    if (ids.Count > 0)
        contact.ID = ids.Dequeue();

    if (phones.Count > 0)
        contact.Phone = phones.Dequeue();

    contacts.Add(contact);
}

var xml = new XElement("Contacts");

foreach (var c in contacts)
{
    xml.Add(new XElement("Contact",
        new XElement("Name", c.Name ?? ""),
        new XElement("ID", c.ID ?? ""),
        new XElement("Phone", c.Phone)
    ));
}

File.WriteAllText("contacts.xml", xml.ToString());

Console.WriteLine("Contacts saved to contacts.xml");