import turtle
import random

turtle.shape("turtle")
turtle.Screen().colormode(255)
turtle.Screen().bgcolor("#c7f0d2")
turtle.speed("fastest")

turtle_list = []

for i in range(5):
    turtle_i = turtle.Turtle()
    turtle_i.speed("fastest")
    turtle_i.penup()
    turtle_i.goto(random.randint(-200, 200), random.randint(-200, 200))
    turtle_list.append(turtle_i)

while True:
    for t in turtle_list:
        t.speed("fastest")
        # Pick a random color
        r = random.randint(0, 255)
        g = random.randint(0, 255)
        b = random.randint(0, 255)
        t.color(r, g, b)
        t.begin_fill()
        t.pendown()
        for i in range(4):
            t.forward(50)
            t.right(90)
        t.end_fill()

turtle.mainloop()