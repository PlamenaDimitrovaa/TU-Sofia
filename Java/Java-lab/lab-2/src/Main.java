import java.util.Arrays;

public class Main {
    public static void main(String[] args) {
        Car kola1 = new Car("Peugeot","206","slow","manual",86,2003);
        Car kola2 = new Car("Audi","A7","fast","automatic",315,2019);
        Car kola3 = new Car("BMW","M5","fast","automatic",289,2015);
        Car kola4 = new Car("Suzuki","Vitara","slow","manual",90,2002);
        Car kola5 = new Car("Toyota","Camry","medium","automatic",170,2019);
        Car kola6 = new Car("Mercedes","G-class","fast","automatic",305,2015);
        Car[] cars = {kola1,kola2,kola3,kola4,kola5,kola6};

        System.out.println(Arrays.toString(Car.filter(cars,'t')));
    }
}

