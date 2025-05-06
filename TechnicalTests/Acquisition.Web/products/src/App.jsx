import { useState, useEffect } from 'react';
import { FaStar } from 'react-icons/fa';
import './App.css';
import api from './api'; // Import the BFF module

function Modal({ isOpen, onClose, children }) {
  if (!isOpen) return null;

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        {children}
        <button className="modal-close" onClick={onClose}></button>
      </div>
    </div>
  );
}

function App() {
  const [products, setProducts] = useState([]);
  const [wishlist, setWishlist] = useState(() => {
    const savedWishlist = localStorage.getItem('wishlist');
    return savedWishlist ? JSON.parse(savedWishlist) : [];
  });
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const data = await api.getProducts();
        setProducts(data);
      } catch (error) {
        console.error('Error fetching products:', error);
        alert('Failed to fetch products. Please check your internet connection or try again later.');
      }
    };

    fetchProducts();
  }, []);

  const handleLogin = async () => {
    if (!username || !password) {
      alert('Username and password are required');
      return;
    }

    try {
      const data = await api.login({ username, password });
      if (data.token) {
        setIsLoggedIn(true);
        setIsLoginModalOpen(false);
        alert('Login successful!');
      } else {
        alert('Invalid credentials');
      }
    } catch (error) {
      console.error('Error during login:', error);
    }
  };

  const toggleWishlist = async (product) => {
    try {
      let updatedWishlist;
      if (wishlist.includes(product.id)) {
        await api.removeFromWishlist(product.id);
        updatedWishlist = wishlist.filter((id) => id !== product.id);
      } else {
        await api.addToWishlist(product.id);
        updatedWishlist = [...wishlist, product.id];
      }

      setWishlist(updatedWishlist);
      localStorage.setItem('wishlist', JSON.stringify(updatedWishlist));
    } catch (error) {
      console.error('Error updating wishlist:', error);
      alert('Failed to update wishlist. Please try again later.');
    }
  };

  const addToBasket = (product) => {
    if (!isLoggedIn) {
      setIsLoginModalOpen(true);
      return;
    }
    alert(`Item ${product.title} added to basket`);
  };

  return (
    <div className="App">
      <h1>Product List</h1>
      <button onClick={() => setIsLoginModalOpen(true)}>Login</button>
      <Modal isOpen={isLoginModalOpen} onClose={() => setIsLoginModalOpen(false)}>
        <div className="login-form">
          <input
            type="text"
            placeholder="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
          <input
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          <button onClick={handleLogin}>Login</button>
        </div>
      </Modal>
      <div className="product-list">
        {products.map((product) => (
          <div key={product.id} className="product-item">
            <img src={product.image} alt={product.title} className="product-image" />
            <h2>{product.title}</h2>
            <p>${product.price}</p>
            <button onClick={() => toggleWishlist(product)} className="wishlist-button">
              <FaStar color={wishlist.includes(product.id) ? 'gold' : 'gray'} />
            </button>
            <button onClick={() => addToBasket(product)}>Add to Basket</button>
          </div>
        ))}
      </div>
    </div>
  );
}

export default App;
