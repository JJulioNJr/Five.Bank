namespace Five.Bank.Domain.Specification.V1;
public class CustomerMajoritySpecification {

    private readonly DateTime _bithday;

    public CustomerMajoritySpecification(DateTime bithday) {
        _bithday = bithday;
    }

    public bool IsSatisfied() => DateTime.Now.Year - _bithday.Year >= 18;
}

