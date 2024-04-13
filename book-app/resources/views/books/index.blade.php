<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Library Catalog</title>
    <!-- Include Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
   <link rel="stylesheet" href="styles.css">
</head>
<body>
    <div class="container">
        <div class="search-bar">
            <form action="{{ url('/books/search') }}" method="GET">
                <div class="form-group">
                    <input type="text" class="form-control" name="search" placeholder="Search books by title">
                </div>
                <button type="submit" class="btn btn-primary">Search</button>
            </form>
        </div>

        <table class="table table-bordered">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Title</th>
                    <th scope="col">Author ID</th>
                    <th scope="col">ISBN</th>
                    <th scope="col">Year Published</th>
                    <th scope="col">Available</th>
                </tr>
            </thead>
            <tbody>
                @foreach ($books as $book)
                <tr>
                    <td>{{ $book->id }}</td>
                    <td>{{ $book->title }}</td>
                    <td>{{ $book->authorid }}</td>
                    <td>{{ $book->ISBN }}</td>
                    <td>{{ $book->pub_year }}</td>
                    <td>{{ $book->available ? 'Yes' : 'No' }}</td>
                </tr>
                @endforeach
            </tbody>
        </table>
    </div>
    <!-- Include Bootstrap JS and jQuery -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.7.0/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
