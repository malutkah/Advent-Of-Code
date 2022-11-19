package Helper

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

/*
	- create day
	-y => year
	-d => day
		aoc new -y -d [year] [day]
		=>	aoc new -y -d 2021 1
		=>	aoc new -y 2021
		=>	aoc new -d 2 at -y 2021

	- start day
		aoc start [day] [year]
			aoc start 4 2021
*/
/* ========== CREATE NEW DAY ============================================================================================== */

func NewDay(day, year string) {
	d, _ := strconv.Atoi(day)
	y, _ := strconv.Atoi(year)

	if isYearValid(y) && isDayValid(d) {
		day = "day" + day

		templateText := setTemplateValues(year, day)
		createTemplate(year, day, templateText)

		fmt.Printf("Created %v in year %v", day, year)
	} else {
		fmt.Println("No valid day or year was entered!")
		fmt.Println("Day has to be between 1 and 25!")
		fmt.Println("The year has to be between 2015 and 2022!")
	}
}

func isDayValid(day int) bool {
	return day > 0 && day < 26
}

func isYearValid(year int) bool {
	return year > 2014 && year < 2023
}

func setTemplateValues(year, day string) string {
	f, err := os.Open("Helper/AoCTemplate.txt")
	if err != nil {
		log.Fatal(err)
	}

	defer func(f *os.File) {
		err := f.Close()
		if err != nil {
			panic(err)
		}
	}(f)

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

/* ======================================================================================================== */

/* ========== START A DAY ================================================================================================= */

func StartDay(day, year string) {
	// check if year is available (is year a dir?)
	// check if day is available (is day a dir in year?)
}

func isYearDirectory(year string) bool {

	return true
}

func isDayInsideYear(day, year string) bool {

	return true
}

/* ======================================================================================================== */
