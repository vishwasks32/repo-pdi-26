export default function ProductTable({ products }: { products: any[] }) {
  return (
    <div className="overflow-x-auto rounded-lg border border-gray-200 shadow-sm">
      <table className="min-w-full divide-y divide-gray-200 bg-white text-sm">
        <thead className="bg-gray-50">
          <tr>
            <th className="px-4 py-3 text-left font-semibold text-gray-900">Name</th>
            <th className="px-4 py-3 text-left font-semibold text-gray-900">Category</th>
            <th className="px-4 py-3 text-left font-semibold text-gray-900">Price</th>
            <th className="px-4 py-3 text-right font-semibold text-gray-900">Actions</th>
          </tr>
        </thead>
        <tbody className="divide-y divide-gray-100">
          {products.map((p) => (
            <tr key={p.id} className="hover:bg-gray-50 transition-colors">
              <td className="px-4 py-3 text-gray-700">{p.name}</td>
              <td className="px-4 py-3">
                <span className="rounded-full bg-blue-100 px-2.5 py-0.5 text-xs font-medium text-blue-800">
                  {p.category}
                </span>
              </td>
              <td className="px-4 py-3 text-gray-700">${p.price}</td>
              <td className="px-4 py-3 text-right">
                <button className="text-indigo-600 hover:text-indigo-900 font-medium">Edit</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}