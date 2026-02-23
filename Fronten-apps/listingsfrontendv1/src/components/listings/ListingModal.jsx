import { useEffect, useRef } from "react";

function ListingModal({ listing, showModal, onClose }) {
  const modalRef = useRef(listing);

  useEffect(()=>{
    if(showModal){
      modalRef.current?.showModal();
    } else {
      modalRef.current?.close();
    }
  },[showModal]);
  return (
    <>
      <dialog ref={modalRef} className="modal" onClose={onClose}>
        <div className="modal-box w-11/12 max-w-5xl">
          <figure className="w-full">
            <img 
            src={listing.image? listing.image: "images/house.jpg"}
            alt={listing?.name}
            className="w-full h-auto object-cover max-h-[70vh]"
            ></img>
          </figure>
        </div>
        <form method="dialog" className="modal-backdrop">
          <button className="btn btn-sm btn-circle btn-ghost absolute right-2 top-2" onClick={onClose}>X</button>
        </form>
      </dialog>
    </>
  );
}

export default ListingModal;
