/*
Copyright © 2024 malutkah <alan.tressin@outlook.com>
*/
package main

import (
	"AoC/cmd"
	"os"
)

func main() {
	err := os.Setenv("SOLVE_DAY1", "false")
	if err != nil {
		return
	}
	cmd.Execute()

	if shouldSolve() {
		//day1.Solve()
	}
}

func shouldSolve() bool {
	return os.Getenv("SOLVE_DAY1") == "true"
}
