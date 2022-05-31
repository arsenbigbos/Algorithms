#include <stdio.h>
#include <math.h>



#define eps 0.0001
double fx(double x) { return 2 * x - log(x) - 4; } // дана функція 
double dfx(double x) { return 2 - 1 / x; } // похідна функції

typedef double(*function)(double x); // завдання типу  function

double solve(function fx, function dfx, double x0) {
    int n = 1;
    printf("xNext = x0 - f(x0) / df(x0)\n");
    printf("x0 = %f\n", x0);
    printf("fx(x0) = %f\n", fx(x0));
    printf("dfx(x0) = %f\n", dfx(x0));
    double x1 = x0 - fx(x0) / dfx(x0); // перше наближення 
    printf("xNext(x0) = %f\n", x1);
    printf("the number of iterations = %d\n\n", n);
    while (fabs(x1 - x0) > eps) { // допоки не досягнута точність 0.0001
        x0 = x1;
        printf("xNext = x0 - f(x0) / df(x0)\n");
        printf("x0 = %f\n", x0);
        printf("fx(x0) = %f\n", fx(x0));
        printf("dfx(x0) = %f\n", dfx(x0));
        x1 = x0 - fx(x0) / dfx(x0); // наступні наближення
        printf("xNext(x0) = %f\n", x1);
        n++;
        printf("the number of iterations = %d", n);
        printf("\nPohubka  = %f\n\n", fabs(x1 - x0));

    }
    return x1;
}

int main() {
    printf("result %f\n", solve(fx, dfx, 4)); // вивід
    return 0;
}