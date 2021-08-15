# Uses python3
def fib(n):
    if(n==0):
        return 0
    myarray=[None] * (n+1)
    myarray[0]=0
    myarray[1]=1
    for i in range(2,n+1):
        myarray[i]=(myarray[i-1]+myarray[i-2])
    return myarray[n]
def fibonacci_sum_naive(n):
        t1=(n)%60
        t2=(n-1)%60
        fibonachi1=fib(t1)
        fibonachi2=fib(t2)
        res=(fibonachi1 *(fibonachi2+fibonachi1) )%10;
        if(res<0):
            return 10+res
        return res 



toks=int(input())
print(fibonacci_sum_naive(toks))

