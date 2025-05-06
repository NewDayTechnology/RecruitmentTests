const api = {
  async getProducts() {
    let retries = 3;
    while (retries > 0) {
      try {
        const response = await fetch('https://fakestoreapi.com/products');
        if (!response.ok) {
          throw new Error('Failed to fetch products');
        }
        return response.json();
      } catch (error) {
        retries -= 1;
        if (retries === 0) {
          throw new Error('Failed to fetch products after multiple attempts');
        }
      }
    }
  },

  async login(credentials) {
    const response = await fetch('/api/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(credentials),
    });
    if (!response.ok) {
      throw new Error('Login failed');
    }
    return response.json();
  },

  async addToWishlist(productId) {
    const response = await fetch(`/api/wishlist/${productId}`, {
      method: 'POST',
    });
    if (!response.ok) {
      throw new Error('Failed to add to wishlist');
    }
  },

  async removeFromWishlist(productId) {
    const response = await fetch(`/api/wishlist/${productId}`, {
      method: 'DELETE',
    });
    if (!response.ok) {
      throw new Error('Failed to remove from wishlist');
    }
  },
};

export default api;