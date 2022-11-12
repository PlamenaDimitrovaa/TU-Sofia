public class DebitAccount extends BankAccount{

    public DebitAccount(double amount, double interest){
        super(amount, interest);
    }
    @Override
    public double pay(){
        return getAmount() + getAmount()*getInterest();
    }
}
