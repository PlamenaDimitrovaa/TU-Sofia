public class Customer {

    private int customerId;
    private String customerName;
    private double customerAmount;

    public Customer(int customerId, String customerName, double customerAmount){
        this.customerId = customerId;
        this.customerName = customerName;
        this.customerAmount = customerAmount;
    }

    public int getCustomerId(){
        return this.customerId;
    }

    public void setCustomerId(int customerId){
        this.customerId = customerId;
    }

    public String getCustomerName(){
        return this.customerName;
    }

    public void setCustomerName(String customerName){
        this.customerName = customerName;
    }

    public double getCustomerAmount(){
        return this.customerAmount;
    }

    public void setCustomerAmount(double customerAmount){
        this.customerAmount = customerAmount;
    }
}
