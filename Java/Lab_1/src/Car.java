public abstract class Car extends Vehicle implements IsLandVehicle {
    private double power;

    public Car(int maxSpeed, String model, double price, double power){
        super(maxSpeed, model, price);
        this.power = power;
    }

    public double getPower(){
        return this.power;
    }

    public void setPower(double power){
        this.power = power;
    }

    public double checkPromo(){
        return this.getPrice() * 0.3 / 100;
    }
}
