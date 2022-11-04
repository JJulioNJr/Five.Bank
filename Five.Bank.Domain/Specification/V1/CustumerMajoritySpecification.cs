namespace Five.Bank.Domain.Specification.V1;
public class CustumerMajoritySpecification {

    private readonly DateOnly _bithday;

    public CustumerMajoritySpecification(DateOnly bithday) {
        _bithday = bithday;
    }

    public bool IsSatified() {
        return DateTime.Now.Year - _bithday.Year >= 18;
    }
}

