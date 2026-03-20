"use client";
import { useEffect, useState } from 'react';
import api from '@/lib/api';
import ProductTable from '@/components/ProductTable';

export default function ProductsPage() {
  const [data, setData] = useState<any>(null);
  const [page, setPage] = useState(1);
  const [search, setSearch] = useState("");

  const fetchProducts = async () => {
    const res = await api.get(`/products?pageNumber=${page}&searchTerm=${search}`);
    setData(res.data); // This is your PagedResponse
  };

  useEffect(() => { fetchProducts(); }, [page, search]);

  return (
    <div className="p-8 max-w-6xl mx-auto">
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-bold text-gray-800">Inventory</h1>
        <input 
          type="text" 
          placeholder="Search products..." 
          className="border p-2 rounded-md w-64 focus:ring-2 focus:ring-blue-500 outline-none"
          onChange={(e) => setSearch(e.target.value)}
        />
      </div>

      {data?.success && <ProductTable products={data.data} />}

      {/* Pagination Controls */}
      <div className="mt-6 flex gap-2">
        <button 
          disabled={!data?.hasPrevious}
          onClick={() => setPage(p => p - 1)}
          className="px-4 py-2 bg-gray-100 rounded disabled:opacity-50"
        >
          Previous
        </button>
        <span className="py-2 px-4">Page {page} of {data?.totalPages}</span>
        <button 
          disabled={!data?.hasNext}
          onClick={() => setPage(p => p + 1)}
          className="px-4 py-2 bg-gray-100 rounded disabled:opacity-50"
        >
          Next
        </button>
      </div>
    </div>
  );
}