def fib(n):
    if(n==0):
        return 0
    myarray=[None] * (n+1)
    myarray[0]=0
    myarray[1]=1
    for i in range(2,n+1):
        myarray[i]=(myarray[i-1]%10+myarray[i-2]%10)%10
    return myarray[n]
def fibonacci_partial_sum(m, n):
    if(m>n):
        (m,n)=(n,m)
    t1=(n+2)%60
    t2=(m+1)%60
    fibonachiSum1=(fib(t1)-1)
    fibonachiSum2=(fib(t2)-1)
    res=(fibonachiSum1-fibonachiSum2)%10
    if((res)<0):
        return 10+res
    return res 




toks=input().split()
f=int(toks[0])
t=int(toks[1])
print(fibonacci_partial_sum(f,t))