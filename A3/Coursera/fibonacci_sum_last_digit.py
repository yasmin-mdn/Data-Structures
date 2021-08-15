# Uses python3
def calc_fib(n):
    if(n==0):
        return 0
    myarray=[None] * (n+1)
    myarray[0]=0
    myarray[1]=1
    for i in range(2,n+1):
        myarray[i]=(myarray[i-1]+myarray[i-2])
    return myarray[n]
def fibonacci_sum_naive(n):
    if n <= 1:
        return n

    pisano=60
    r=(n+2)%pisano
    return (calc_fib(r)-1)%10



toks=int(input())
print(fibonacci_sum_naive(toks))
