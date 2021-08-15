# Uses python3
import sys
def calc_fib(n):
    if(n==0):
        return 0
    myarray=[0] * (n+1)
    myarray[0]=0
    myarray[1]=1
    for i in range(2,n+1):
        myarray[i]=(myarray[i-1]+myarray[i-2])%10
    return myarray[n]

   

n = int(input())
print(calc_fib(n))

