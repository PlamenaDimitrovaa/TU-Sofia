#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i;
    int N;
    int K;
    int count = 0;
    printf("Insert N: ");
    scanf("%d", &N);
    printf("Insert K: ");
    scanf("%d", &K);
    for(i=0; i<=N; i++)
    {
        scanf("%d", &N);
        if(N % 3 == 0 && N > K)
        {
            count++;
        }
    }
    printf("%d\n", count);

    return 0;
}
