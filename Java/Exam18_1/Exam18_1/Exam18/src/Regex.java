import java.io.Serializable;

public class Regex implements Serializable {

    private int id;
    private String pattern;
    private String description;
    private int rating;
    private static int nextId = 0;

    public Regex(String pattern, String description) {
        this.pattern = pattern;
        this.description = description;
        this.rating = 0;
        this.id = nextId;
        nextId += 1;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getPattern() {
        return pattern;
    }

    public void setPattern(String pattern) {
        this.pattern = pattern;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public int getRating() {
        return rating;
    }

    public void setRating(int rating) {
        this.rating = rating;
    }

    public static int getNextId() {
        return nextId;
    }

    public static void setNextId(int nextId) {
        this.nextId = nextId;
    }
}
