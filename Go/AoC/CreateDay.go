package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strings"
)

func main() {
	var day string
	var year string
	var templateText string

	// get year -> input: number
	fmt.Println("Enter the year (yyyy): ")
	_, yerr := fmt.Scan(&year)
	if yerr != nil {
		return
	}

	// get day -> input: number
	fmt.Println("Enter the day: ")
	_, derr := fmt.Scan(&day)
	if derr != nil {
		return
	}
	day = "day" + day
	//y := "\"" + year + "\""
	//d := "\"" + day + "\""
	//a := "\"AoC/Helper\""
	//imprt := "import aoc " + a
	//templateText = "package " + day + "\n\n" + imprt + "\n\nfunc Test() {\nvar inputs = aoc.GetInput(" + y + ", " + d + ", \"test\"" + ")\n}"
	templateText = setTemplateValues(year, day)

	// get template
	createTemplate(year, day, templateText)
}

func setTemplateValues(year, day string) string {
	f, err := os.Open("Helper/AoCTemplate.txt")
	if err != nil {
		log.Fatal(err)
	}

	defer f.Close()

	scanner := bufio.NewScanner(f)

	var inputs []string

	for scanner.Scan() {
		inputs = append(inputs, scanner.Text())
	}

	for i := 0; i < len(inputs); i++ {
		if strings.Contains(inputs[i], "day") {
			inputs[i] = strings.Replace(inputs[i], "day", day, -1)
		}
		if strings.Contains(inputs[i], "year") {
			inputs[i] = strings.Replace(inputs[i], "year", year, -1)
		}
	}

	return strings.Join(inputs, "\n")
}

func createDayFolder(year string, day string) {
	if _, err := os.Stat("/" + year); os.IsNotExist(err) {
		// dir of that year does not exist
		if err := os.MkdirAll(year+"/"+day, os.ModePerm); err != nil {
			return
		}
	} else {
		if err := os.MkdirAll("/"+year+"/"+day, os.ModePerm); err != nil {
			return
		}
	}

}

func createTemplate(year string, day string, templateText string) {
	createDayFolder(year, day)

	var path = year + "/" + day + "/"

	err := os.WriteFile(path+day+".go", []byte(templateText), 0755)
	if err != nil {
		fmt.Printf("Unable to write file: %v", err)
	}

	err = os.WriteFile(path+"input.txt", []byte(""), 0755)
	if err != nil {
		fmt.Printf("Unable to write file: %v", err)
	}

	err = os.WriteFile(path+"test.txt", []byte(""), 0755)
	if err != nil {
		fmt.Printf("Unable to write file: %v", err)
	}
}
