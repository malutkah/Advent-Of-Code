/*
Copyright © 2024 malutkah <alan.tressin@outlook.com>
*/
package main

import (
	"AoC/2023/day1"
	"AoC/cmd"
	"os"
)

func main() {
	cmd.Execute()

	if shouldSolve() {
		day1.Solve()
	}
}

func shouldSolve() bool {
	return os.Getenv("SOLVE_DAY1") == "true"
}
