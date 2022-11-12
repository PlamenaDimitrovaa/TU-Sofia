public class Company_ET extends Company{

    private String Owner;
    private double StartCap;
    private double ActualCap;

    public Company_ET(String Name, String DateOfCreation, String ID,
                      String Owner, double StartCap, double ActualCap) {
        super(Name, DateOfCreation, ID);
        this.Owner = Owner;
        this.StartCap = StartCap;
        this.ActualCap = ActualCap;
    }

    public String getOwner() {
        return Owner;
    }

    public void setOwner(String owner) {
        Owner = owner;
    }

    public double getStartCap() {
        return StartCap;
    }

    public void setStartCap(double startCap) {
        StartCap = startCap;
    }

    public double getActualCap() {
        return ActualCap;
    }

    public void setActualCap(double actualCap) {
        ActualCap = actualCap;
    }

    public double ProfitByNow(){
        return getActualCap() - getStartCap();
    }

}
