import { render, screen, fireEvent } from '@testing-library/react';
import App from './App';

// Mock localStorage
const localStorageMock = (() => {
  let store = {};
  return {
    getItem: (key) => store[key] || null,
    setItem: (key, value) => {
      store[key] = value.toString();
    },
    clear: () => {
      store = {};
    },
  };
})();
Object.defineProperty(window, 'localStorage', { value: localStorageMock });

describe('App Component', () => {
  beforeEach(() => {
    window.localStorage.clear();
  });

  test('renders product list', async () => {
    // Mock fetch API
    global.fetch = jest.fn(() =>
      Promise.resolve({
        json: () =>
          Promise.resolve([
            {
              id: 1,
              title: 'Test Product',
              price: 10.99,
              image: 'test-image-url',
            },
          ]),
      })
    );

    render(<App />);

    // Check if product is rendered
    const productTitle = await screen.findByText('Test Product');
    expect(productTitle).toBeInTheDocument();

    // Clean up mock
    global.fetch.mockClear();
  });

  test('adds and removes product from wishlist', async () => {
    // Mock fetch API
    global.fetch = jest.fn(() =>
      Promise.resolve({
        json: () =>
          Promise.resolve([
            {
              id: 1,
              title: 'Test Product',
              price: 10.99,
              image: 'test-image-url',
            },
          ]),
      })
    );

    render(<App />);

    // Wait for product to load
    const addButton = await screen.findByText('Add to Wishlist');
    expect(addButton).toBeInTheDocument();

    // Add to wishlist
    fireEvent.click(addButton);
    expect(screen.getByText('Remove from Wishlist')).toBeInTheDocument();

    // Remove from wishlist
    fireEvent.click(screen.getByText('Remove from Wishlist'));
    expect(screen.getByText('Add to Wishlist')).toBeInTheDocument();

    // Clean up mock
    global.fetch.mockClear();
  });

  test('adds product to basket after login', async () => {
    // Mock fetch API
    global.fetch = jest.fn((url, options) => {
      if (url.includes('/login')) {
        return Promise.resolve({
          json: () => Promise.resolve({ token: 'test-token' }),
        });
      }
      if (url.includes('/products')) {
        return Promise.resolve({
          json: () =>
            Promise.resolve([
              {
                id: 1,
                title: 'Test Product',
                price: 10.99,
                image: 'test-image-url',
              },
            ]),
        });
      }
      return Promise.reject(new Error('Unknown API endpoint'));
    });

    render(<App />);

    // Wait for product to load
    const addButton = await screen.findByText('Add to Basket');
    expect(addButton).toBeInTheDocument();

    // Attempt to add to basket without login
    fireEvent.click(addButton);
    expect(screen.getByText('Please log in to add items to the basket')).toBeInTheDocument();

    // Perform login
    fireEvent.change(screen.getByPlaceholderText('Username'), {
      target: { value: 'testuser' },
    });
    fireEvent.change(screen.getByPlaceholderText('Password'), {
      target: { value: 'password123' },
    });
    fireEvent.click(screen.getByText('Login'));

    // Wait for login to complete
    await screen.findByText('Welcome, testuser');

    // Add to basket after login
    fireEvent.click(addButton);
    expect(screen.getByText('Item added to basket')).toBeInTheDocument();

    // Clean up mock
    global.fetch.mockClear();
  });
});