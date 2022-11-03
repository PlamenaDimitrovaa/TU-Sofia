public abstract class Hovercraft extends Vehicle implements IsSeaVessel {
    private int passengers;

    public Hovercraft(int maxSpeed, String model, double price, int passengers){
        super(maxSpeed, model, price);
        this.passengers = passengers;
    }

    public int getPassengers(){
        return this.passengers;
    }

    public void setPassengers(int passengers){
        this.passengers = passengers;
    }

    public double checkPromo(){
        return this.getPrice() * 0.97;
    }
}
