#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// 'Artist' structure (part of the first task):
typedef struct
{
    char* name;
    int age;
    char* country;
    int income;
    int oscar_count;
} artist;

// Create a list with default values:
void create_artists(artist* artists, int size)
{
    for (int i = 0; i < size; i++)
    {
        artists[i].name = (char*) malloc(10*sizeof(char));
        artists[i].age = 0;
        artists[i].country = (char*) malloc(5*sizeof(char));
        artists[i].income = 0;
        artists[i].oscar_count = 0;
    }
}

// First Task:
artist* add_new_artist(artist* artists, int size)
{
    artist* new_artists = (artist*) realloc(artists, (size + 1)*sizeof(artist));
    if (new_artists == NULL)
    {
        printf("Memory allocation error!\n");
        exit(1);
    }
    else
    {
        new_artists[size].name = (char*) malloc(10*sizeof(char));
        new_artists[size].country = (char*) malloc(5*sizeof(char));

        printf("Enter artist name: ");
        scanf("%s", new_artists[size].name);

        printf("Enter artist age: ");
        scanf("%d", &new_artists[size].age);

        printf("Enter artist country: ");
        scanf("%s", new_artists[size].country);

        printf("Enter artist income: ");
        scanf("%d", &new_artists[size].income);

        printf("Enter 'Oscar' count: ");
        scanf("%d", &new_artists[size].oscar_count);
    }
    return new_artists;
}

// Second Task:
artist* artists_with_bigger_income(artist* artists, int size, int income)
{
    int new_size = 0;
    artist* new_artists = NULL;

    for (int i = 0; i < size; i++)
    {
        if (artists[i].income > income)
        {
            new_size++;
            new_artists = (artist*) realloc(new_artists, new_size*sizeof(artist));
            if (new_artists == NULL)
            {
                printf("Memory allocation error!\n");
                exit(1);
            }
            else
            {
                new_artists[new_size - 1].name = (char*) malloc(10*sizeof(char));
                new_artists[new_size - 1].country = (char*) malloc(5*sizeof(char));

                strcpy(new_artists[new_size - 1].name, artists[i].name);
                new_artists[new_size - 1].age = artists[i].age;
                strcpy(new_artists[new_size - 1].country, artists[i].country);
                new_artists[new_size - 1].income = artists[i].income;
                new_artists[new_size - 1].oscar_count = artists[i].oscar_count;
            }
        }
    }
    return new_artists;
}

// Helper function to display artists' data:
void print_artists(artist* artists, int size)
{
    for (int i = 0; i < size; i++)
    {
        printf("%s %d %s %d %d\n", artists[i].name,
                                   artists[i].age,
                                   artists[i].country,
                                   artists[i].income,
                                   artists[i].oscar_count);
    }
}

// Helper function to count the lines in a file:
int count_file_lines(FILE* file)
{
    int counter = 0;
    char row[256];
    // Counter increments at the end of the line:
    while (fgets(row, 256, file) != NULL) {counter++;}
    rewind(file);
    return counter;
}

// Third Task: Read artists from file (reversed):
void fill_artists(FILE* file, artist* artists, int counter)
{
    char buffer[256];
    char* string;

    counter--;
    while (fgets(buffer, 256, file) != NULL)
    {
        string = strtok(buffer, ";");
        strcpy(artists[counter].name, string);

        string = strtok(NULL, ";");
        artists[counter].age = atoi(string);

        string = strtok(NULL, ";");
        strcpy(artists[counter].country, string);

        string = strtok(NULL, ";");
        artists[counter].income = atoi(string);

        string = strtok(NULL, ";");
        artists[counter].oscar_count = atoi(string);
        counter--;
    }
}

void free_artists(artist* artists, int size)
{
    for (int i = 0; i < size; i++)
    {
        free(artists[i].name);
        free(artists[i].country);
    }
    free(artists);
}

int main()
{
    // Test #1:
     artist* artists = (artist*) malloc(3*sizeof(artist));
     create_artists(artists, 3);

     artists[0].name = "Johnny";
     artists[0].age = 58;
     artists[0].country = "USA";
     artists[0].income = 1000;
     artists[0].oscar_count = 0;

     artists[1].name = "Leonardo";
     artists[1].age = 47;
     artists[1].country = "USA";
     artists[1].income = 2600;
     artists[1].oscar_count = 1;

     artists[2].name = "Cate";
     artists[2].age = 53;
     artists[2].country = "AUSTRALIA";
     artists[2].income = 950;
     artists[2].oscar_count = 2;

     // Be careful, when testing the functions!
     // You have to know the exact size of the lists you pass!
     artists = add_new_artist(artists, 3);

     printf("\n");
     print_artists(artists, 4);
     printf("\n");

     artist* new_artists = artists_with_bigger_income(artists, 4, 1100);
     print_artists(new_artists, 2);

    // Test #2:
//    FILE* artist_file;
//
//    if ((artist_file = fopen("artists.TXT", "r")) == NULL)
//    {
//        printf("Error opening the file!");
//        exit(1);
//    }
//
//    int count = count_file_lines(artist_file);
//
//    artist* artists = (artist*) malloc(count*sizeof(artist));
//    create_artists(artists, count);
//    fill_artists(artist_file, artists, count);
//
//    print_artists(artists, count);
//    free_artists(artists, count);

    return 0;
}
