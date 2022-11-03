#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// 'Product' Structure (part of the first task):
typedef struct
{
    char* name;
    int ID;
    char* expiration_date;
    float price;
} product;

product create_product()
{
    product product;
    product.name = (char*) malloc(31*sizeof(char));
    product.expiration_date = (char*) malloc(11*sizeof(char));
    product.ID = 0;
    product.price = 0;

    return product;
}

void create_product_list(product* product_list, int size)
{for (int i = 0; i < size; i++) {product_list[i] = create_product();}}

void create_binary_file(product* product_list, int size)
{
    FILE* file_pointer;
    if ((file_pointer = fopen("products.bin", "wb")) == NULL)
    {
        printf("Error opening file!");
        exit(1);
    }

    for (int i = 0; i < size; i++) {fwrite((product_list + i), sizeof(product), 1, file_pointer);}
    fclose(file_pointer);
}

void add_product_to_file(product* product)
{
    FILE* file_pointer;
    if ((file_pointer = fopen("products.bin", "wa")) == NULL)
    {
        printf("Error opening file!");
        exit(1);
    }

    fwrite(product, sizeof(product), 1, file_pointer);
    fclose(file_pointer);
}

product* expiration_date_products(product* product_list, int size, char* expiration_date)
{
    int new_size = 0;
    product* new_product_list = NULL;

    for (int i = 0; i < size; i++)
    {
        if (strcmp(product_list[i].expiration_date, expiration_date) == 0)
        {
            new_size++;
            new_product_list = (product*) realloc(new_product_list, new_size*sizeof(product));
            if (new_product_list == NULL)
            {
                printf("Memory allocation error!\n");
                exit(1);
            }
            else
            {
                new_product_list[new_size - 1].name = (char*) malloc(31*sizeof(char));
                new_product_list[new_size - 1].expiration_date = (char*) malloc(11*sizeof(char));

                strcpy(new_product_list[new_size - 1].name, product_list[i].name);
                new_product_list[new_size - 1].ID = product_list[i].ID;
                strcpy(new_product_list[new_size - 1].expiration_date, product_list[i].expiration_date);
                new_product_list[new_size - 1].price = product_list[i].price;
            }
        }
    }
    return new_product_list;
}

void print_products(product* product_list, int size)
{
    for (int i = 0; i < size; i++)
    {
        printf("%s\n", product_list[i].name);
        printf("%d\n", product_list[i].ID);
        printf("%s\n", product_list[i].expiration_date);
        printf("%.2f\n", product_list[i].price);
        printf("\n");
    }
}

product* add_new_product(product* product_list, int size)
{
    product* new_products = (product*) realloc(product_list, (size + 1)*sizeof(product));
    if (new_products == NULL)
    {
        printf("Memory allocation error!\n");
        exit(1);
    }
    else
    {
        new_products[size].name = (char*) malloc(31*sizeof(char));
        new_products[size].expiration_date = (char*) malloc(11*sizeof(char));

        printf("Enter Product Name: ");
        fgets(new_products[size].name, 31*sizeof(char), stdin);
        new_products[size].name[strcspn(new_products[size].name, "\n")] = 0;
        fflush(stdin);

        printf("Enter Product ID: ");
        scanf("%d", &new_products[size].ID);

        printf("Enter Product Expiration Date: ");
        scanf("%s", new_products[size].expiration_date);

        printf("Enter Product Price: ");
        scanf("%f", &new_products[size].price);
    }

    add_product_to_file(&product_list[size]);
    return new_products;
}

void save_product_to_text_file(product* product)
{
    FILE* file_pointer;
    if ((file_pointer = fopen("products.txt", "a")) == NULL)
    {
        printf("Error opening file!");
        exit(1);
    }
    else
    {fprintf(file_pointer, "Name = %s\n ID = %d\n Expiration Date = %s\n Price = %f\n", product->name,
                                                                                   product -> ID,
                                                                                   product->expiration_date,
                                                                                   product->price);}
    fclose(file_pointer);
}

void binary_to_text()
{
    FILE* file_pointer;

    product product;

    if ((file_pointer = fopen("products.bin", "r")) == NULL)
    {
        printf("Error opening file!");
        exit(1);
    }
    else
    {while (fread(&product, sizeof(product), 1, file_pointer)){save_product_to_text_file(&product);}}

    fclose(file_pointer);
}

void print_from_binary()
{
     FILE* file_pointer;
     product product;

    if ((file_pointer = fopen("products.bin", "r")) == NULL)
    {
        printf("Error opening file!");
        exit(1);
    }
    else
    {
        while (fread(&product, sizeof(product), 1, file_pointer))
        {printf("Name = %s\n ID = %d\n Expiration Date = %s\n Price= %f\n", product.name,
                                                                      product.ID,
                                                                      product.expiration_date,
                                                                      product.price);}
    }
    fclose(file_pointer);
}

void print_from_text()
{
    FILE* file_pointer;
    char buffer[256];
    if ((file_pointer = fopen("products.txt", "r")) == NULL)
    {
        printf("Error opening file!");
        exit(1);
    }
    else
    {
        while (fgets(buffer, 256, file_pointer))
        {
             buffer[strcspn(buffer, "\n")] = 0;
             printf("%s\n", buffer);
        }
    }
    fclose(file_pointer);
}

void free_products(product* product_list, int size)
{
    for (int i = 0; i < size; i++)
    {
        free(product_list[i].name);
        free(product_list[i].expiration_date);
    }

    free(product_list);
}

int main()
{
    product* product_list = (product*) malloc(2*sizeof(product));
    create_product_list(product_list, 2);

    strcpy(product_list[0].name, "Milk");
    product_list[0].ID = 1;
    strcpy(product_list[0].expiration_date, "2022.10.15");
    product_list[0].price = 2.30;

    strcpy(product_list[1].name, "Bread");
    product_list[1].ID = 2;
    strcpy(product_list[1].expiration_date, "2022.07.15");
    product_list[1].price = 1.25;

    create_binary_file(product_list, 2);

// Test #1:
    product_list = add_new_product(product_list, 2);
    product* expired_products = expiration_date_products(product_list, 3, "2022.10.15");
    print_products(expired_products, 2);

// Test #2:
//    binary_to_text();
//    printf("Binary Item:\n");
//    print_from_binary();
//    printf("Text Item:\n");
//    print_from_text();
//    free_products(product_list, 2);

    return 0;
}

