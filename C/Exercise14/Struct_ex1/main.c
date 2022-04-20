#include <stdio.h>
#include <stdlib.h>

typedef struct{
    int x;
    int y;
} point;

typedef struct{
    point points[3];
} triangle;

int main()
{
    point points[3];
    point p1;
    point p2;
    point p3;

    strcpy(p1.x, 10);
    strcpy(p1.y, 12);
    strcpy(p2.x, 8);
    strcpy(p2.y, 9);
    strcpy(p3.x, 18);
    strcpy(p3.y, 20);

    points[0] = p1;
    points[1] = p2;
    points[2] = p3;

    triangle trianglee;
    strcpy(trianglee.points, points);

    return 0;
}
