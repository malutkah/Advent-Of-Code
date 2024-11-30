/*
Copyright © 2022 NAME HERE <EMAIL ADDRESS>
*/
package cmd

import (
	"AoC/Helper"
	"fmt"
	"github.com/spf13/cobra"
	"os"
)

// startCmd represents the start command
var startCmd = &cobra.Command{
	Use:   "start",
	Short: "Starts the specified day and year for the Advent of Code challenge",
	Long: `The start command initializes the specified day and year for the Advent of Code challenge.

Usage:
  aoc start [day] [year]

Examples:
  aoc start 1 2023  # Starts the challenge for day 1 of the year 2023
  aoc start 15 2022 # Starts the challenge for day 15 of the year 2022

This command sets up the necessary files and environment to begin solving the challenge for the specified day and year.`,
	Run: func(cmd *cobra.Command, args []string) {
		if len(args) == 2 {
			os.Setenv("SOLVE_DAY1", "true")
			Helper.StartDay(args[0], args[1])
		} else {
			os.Setenv("SOLVE_DAY1", "false")
			fmt.Println("Invalid arguments! Enter only 2")
		}
	},
}

func init() {
	rootCmd.AddCommand(startCmd)

	// Here you will define your flags and configuration settings.

	// Cobra supports Persistent Flags which will work for this command
	// and all subcommands, e.g.:
	// startCmd.PersistentFlags().String("foo", "", "A help for foo")

	// Cobra supports local flags which will only run when this command
	// is called directly, e.g.:
	// startCmd.Flags().BoolP("toggle", "t", false, "Help message for toggle")
}
