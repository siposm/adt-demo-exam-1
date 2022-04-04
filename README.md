# Advanced Development Techniques Demo Exam #1

```
    Sipos Miklos    
    © siposm
    2022
```

## Detailed video explanation
Can be found here on my YouTube channel: https://youtu.be/xlvAIpY3BZs

<br><br><br><br><br>

# Exercise

Create a **single-layer** console application based on the following tasks.

## Database creation
- Create a service-based database and name it Movies.
- Create Movies table using code first approach.
    - Movies table columns:
        - `Id (int)` – primary key, should be an auto-incremented id (Identity column);
        - `Title (string)` – Title of the movie. Max 80 chars, required field;
        - `Genre (string)` – Genre of the movie;
        - `YearOfRelease (int)` – Year the movie was released.
        - *Note, that the xml contains additional properties as well, which for this moment we'll ignore.*

## XML processing
- Create a static class named `MovieCreator` and inside a method named `CreateMovies` that can create `Movie` objects from the `movies.xml` file (https://users.nik.uni-obuda.hu/siposm/db/movies.xml). In the method create a `Func` delegate which accepts a `string` typed path of the file and returns an `IEnumerable<Movie>` referenced collection.
- Save all the movies into the database.

## Attribute usage
- Create an attribute called `MinimumYearAttribute`.
- Create the attribute so that it can be applied to properties only.
- The attribute should have a `public int` property where the minimum year can be stored and it should have a constructor where this property can be assigned.
- Place the attribute on the `YearOfRelease` property the of the `Movie` class with `1993` as it's input.

## Validation using reflection
Solve this exercise using reflection:
- Create a `Validator` class that can validate a certain property if it has `MinimumYearAttribute` on it. It should contain a method called `IsValid<T>(string propertyName)`, where `T` is the class whose property you want to check and `propertyName` is the name of the property.
- The method should return a `boolean` value, which should be true if the minimum year stored in the attribute is smaller than the property’s value and it should return false otherwise.
- In case the property being validated does not exist or does not have the attribute on it, the method should throw an `ArgumentException`.

## Unit testing
- Create a separate DLL in which we can perform unit testing for the validation.
- Create a class for the `Validator` class that tests the operation of the `IsValid<T>()` method in three ways:
    - Create a test for a property that has the `MinimumYearAttribute` attribute placed on it and has a valid value.
    - Create a test for a property that has the `MinimumYearAttribute` attribute on it, but has an invalid value
    - Create a test for a property that exists, but does not have the `MinimumYearAttribute` on it. Treat any exceptions that may arise in a way that we learned during the semester.

## LINQ data querying
Solve these exercises using LINQ queries and display the result on the console.
- Count how many movies are in each genre and display it as `Genre <> Number` format.
- Display the movies that were released before 1994 in descending order of their title’s length.
- For each movie genre, find the movie that has the longest title, then palce it into a anonymous class that contains the `Genre`, the `Title` of the movie and the `YearOfRelease` property.
