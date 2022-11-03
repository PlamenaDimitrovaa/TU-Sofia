public abstract class Ship extends Vehicle implements IsSeaVessel {

    private double deadWeight;

    public Ship(int maxSpeed, String model, double price, double deadWeight){
        super(maxSpeed, model, price);
        this.deadWeight = deadWeight;
    }

    public double getDeadWeight(){
        return this.deadWeight;
    }

    public void setDeadWeight(double deadWeight){
        this.deadWeight = deadWeight;
    }

    public double checkPromo(){
        return this.getPrice() * 0.8;
    }
}
