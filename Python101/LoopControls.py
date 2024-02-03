# Loop controls statements
# break, continue, pass

import random
import time

running = True
score = 0

while running:
    score += random.randint(1, 10)

    if score > 20:
        pass

    # The break statement terminates the loop immediately
    if score > 100:
        print("Program stops here")
        break

    print(score)

    # The continue statement starts a new iteration immediately
    if score < 50:
        continue

    print("You are close to winning!")
    time.sleep(1)


print("^_^")







