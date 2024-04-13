<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Book;
class BookController extends Controller
{
    public function index()
    {
        $books = Book::all();
        return view('books.index', compact('books'));
    }
    
    public function search(Request $request)
    {
        $searchTerm = $request->input('search');
        $books = Book::query()
                     ->where('title', 'LIKE', "%{$searchTerm}%")
                     ->get();
        return view('books.search', compact('books'));
    }
    
}
