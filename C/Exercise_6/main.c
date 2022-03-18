#include <stdio.h>
#include <stdlib.h>

int main()
{
   double kilometers;
   char period;
   double taxi = 0.70;
   double bus = 0;
   double train = 0;

   printf("Insert kilometers: ");
   scanf("%lf", &kilometers);

   printf("Insert period: ");
   scanf("%s", &period);

   if(period == 'D'){
        taxi += kilometers * 0.79;
        bus = kilometers * 0.09;
        train = kilometers * 0.06;

        if(kilometers < 20){
            printf("%lf", taxi);
        }
        else if(kilometers >= 20 && bus < taxi && bus < train){
            printf("%lf", bus);
        }
        else if(kilometers >= 100 && train < taxi && train < bus){
            printf("%lf", train);
        }
   }
    else if(period == 'N'){
        taxi += kilometers * 0.90;
        bus = kilometers * 0.09;
        train = kilometers * 0.06;

        if(kilometers < 20){
            printf("%lf", taxi);
        }
        else if(kilometers >= 20 && bus < taxi && bus < train){
            printf("%lf", bus);
        }
         else if(kilometers >= 100 && train < taxi && train < bus){
            printf("%lf", train);
        }
   }
    return 0;
}
