#include <stdio.h>
#include <stdlib.h>

typedef struct
{
    char name[30];
    int ID;
    char expiration_date[11];
    double price;
} Product;

//2 zadacha
Product* priced_products(Product* product_list, int* size, double price, int* newSize)
{
    Product* new_list = NULL;

    for(int i = 0; i < *size; i++)
    {
        if(product_list[i].price > price)
        {
            *newSize += 1;
            new_list = (Product*) realloc(new_list, *newSize*sizeof(Product));
            new_list[*newSize - 1] = product_list[i];
        }
    }

    return new_list;
}

//1 zadacha
void add_product(Product new_product, Product* product_list, int* size, FILE * fp)
{
    *size += 1;
    product_list = (Product*) realloc(product_list, *size*sizeof(Product));

    if(product_list == NULL)
    {
        printf("Memory allocation error!\n");
        exit(1);
    }
    else
    {
        product_list[*size - 1] = new_product;
    }

    fwrite(&new_product, sizeof(Product), 1, fp);
}

void print_products(Product* product_list, int* size)
{
    for(int i = 0; i < *size; i++)
    {
        printf("%s\n", product_list[i].name);
        printf("%d\n", product_list[i].ID);
        printf("%s\n", product_list[i].expiration_date);
        printf("%.2f\n", product_list[i].price);
    }
}

int main()
{
    FILE* fp = fopen("in.bin", "wb");
    Product* product_list = (Product*) malloc(1*sizeof(Product));
    int size = 0;
    int* pointerToSize = &size;

    Product product;
    strcpy(product.name, "Hlqb");
    product.ID = 6;
    strcpy(product.expiration_date, "2022.07.25");
    product.price = 3.49;

    add_product(product, product_list, pointerToSize, fp);

    Product new_product;
    strcpy(new_product.name, "Mlqko");
    new_product.ID = 6;
    strcpy(new_product.expiration_date, "2022.07.25");
    new_product.price = 2.50;

    add_product(new_product, product_list, pointerToSize, fp);

    Product last_product;
    strcpy(last_product.name, "Voda");
    last_product.ID = 3;
    strcpy(last_product.expiration_date, "2021.07.25");
    last_product.price = 1.50;

    add_product(last_product, product_list, pointerToSize, fp);

    print_products(product_list, pointerToSize);

    //2 zadacha
    int new_list_size = 0;
    int* pointerToNewListSize = &new_list_size;
    Product* new_list = priced_products(product_list, pointerToSize, 2.00, pointerToNewListSize);
    print_products(new_list, pointerToNewListSize);

    fclose(fp);

    return 0;
}
