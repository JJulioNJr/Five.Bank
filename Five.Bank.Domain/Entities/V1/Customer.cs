﻿using Five.Bank.Domain.Specification.V1;
using Five.Bank.Domain.ValueObjects.V1;

namespace Five.Bank.Domain.Entities.V1;
public sealed class Customer {

    public Customer(string name, string document, DateOnly birthday, Address? address) :
                    this(Guid.NewGuid(), name, document, birthday, address) {
    }

    public Customer(Guid id, string name, string document, DateOnly birthday, Address? address) {
        this.Id = id;
        this.Name = name;
        this.Document = document;
        this.Birthday = birthday;
        this.Address = address;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Document { get; init; }
    public DateOnly Birthday { get; init; }
    public Address? Address { get; init; }

    public bool Validate() {
        var documentSpecication = new DocumentAlgorithmSpecification(Document);
        var birthSpecification = new CustumerMajoritySpecification(Birthday);
        return documentSpecication.IsSatisfied()&& birthSpecification.IsSatified();
    }




}

