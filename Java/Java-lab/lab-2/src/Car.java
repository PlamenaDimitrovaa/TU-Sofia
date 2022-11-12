public class Car {
    private String brand;
    private String model;
    private int hp;
    private String engineType;
    private String transmission;
    private int year;

    public String getBrand() {
        return brand;
    }

    public void setBrand(String brand) {
        this.brand = brand;
    }

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public int getHp() {
        return hp;
    }

    public void setHp(int hp) {
        this.hp = hp;
    }

    public String getEngineType() {
        return engineType;
    }

    public void setEngineType(String engineType) {
        this.engineType = engineType;
    }

    public String getTransmission() {
        return transmission;
    }

    public void setTransmission(String transmission) {
        this.transmission = transmission;
    }

    public int getYear() {
        return year;
    }

    public void setYear(int year) {
        this.year = year;
    }

    public Car(String brand, String model, int hp,
               String engineType, String transmission, int year) {
        this.brand = brand;
        this.model = model;
        this.hp = hp;
        this.engineType = engineType;
        this.transmission = transmission;
        this.year = year;
    }

    public Car(String peugeot, String model, String slow, String manual, int i, int year) {
        this.brand = "";
        this.model = "";
        this.hp = 0;
        this.engineType = "";
        this.transmission = "";
        this.year = 0;
    }

    public static Car[] filter(Car[] cars, char c){
        int counter = 0;
        for (int i = 0; i < cars.length; i++) {
            if(cars[i].brand.charAt(0) == c)
                counter++;
        }
        Car[] result = new Car[counter];

        counter = 0;

        for (int i = 0; i < cars.length; i++) {
            if(cars[i].brand.charAt(0) == c)
                result[counter++] = cars[i];
        }
        return result;
    }

    @Override
    public String toString() {
        return "Car{" +
                "brand='" + brand + '\'' +
                ", model='" + model + '\'' +
                ", hp=" + hp +
                ", engineType='" + engineType + '\'' +
                ", transmission='" + transmission + '\'' +
                ", year=" + year +
                '}';
    }




}
