export default async function Loading() {
    const skeletonRows = Array.from({length:10});

    return (
        <div className="overflow-x-auto">
            <table className="table table-zebra">
                {/* head */}
                <thead>
                    <tr>
                        <th></th>
                        <th>Id</th>
                        <th>Title</th>
                        <th>City</th>
                    </tr>
                </thead>
                <tbody className="gap-3">
                    {skeletonRows.map((_,index) => (
                        <tr key={index}>
                            <td className="skeleton h-4 w-32"></td>
                            <td className="skeleton h-4 w-32"></td>
                            <td className="skeleton h-4 w-32"></td>
                        </tr>
                    ))

                    }
                </tbody>
            </table>
        </div>
    );
}