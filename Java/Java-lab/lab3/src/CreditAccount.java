public class CreditAccount extends BankAccount{
    private int months;


    public CreditAccount(double amount, double interest, int months) {
        super(amount, interest);
        this.months = months;
    }

    public int getMonths() {
        return months;
    }

    public void setMonths(int months) {
        this.months = months;
    }

    @Override
    public double pay(){
        double sum = getAmount();
        for (int i = 0; i < months; i++) {
            sum+= sum * getInterest();
        }
        return sum;
    }

}
