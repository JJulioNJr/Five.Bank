namespace Five.Bank.Api.Models.Inputs;
public class CustomerInputModel {

    public CustomerInputModel(string name, string document, DateTime birthday, string? zipCode) {
        Name = name;
        Document = document;
        Birthday = birthday;
        ZipCode = zipCode;
    }

    public string Name { get; }
    public string Document { get; }
    public DateTime Birthday { get; }
    public string? ZipCode { get; }
}

