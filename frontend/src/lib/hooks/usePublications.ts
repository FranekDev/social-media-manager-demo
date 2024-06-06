'use client';

import { useEffect, useState } from 'react';
import { Publication } from '../types/instagram';

export function usePublications() {
  const [publications, setPublications] = useState<Publication[]>([]);

  useEffect(() => {
    const fetchPublications = async () => {
      const response = await fetch(
        `https://localhost:7112/api/instagramscheduledpost`,
      );

        const data = await response.json();
        setPublications(data);
    };
    fetchPublications();
  }, []);

  console.log({publications});

  return publications;
}
