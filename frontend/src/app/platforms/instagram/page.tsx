'use client';

import ConnectInstagram from '@/components/Platforms/ConnectInstagram';
import InstagramPage from '@/components/Platforms/InstagramPage';
import UserDetails from '@/components/Platforms/UserDetails';
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import { useSession } from 'next-auth/react';
import Link from 'next/link';

export default function Page() {
  const { data: session } = useSession();

  return (
    <div className="flex flex-col justify-between gap-6 h-full">
      {session ? (
        <InstagramPage />
      ) : (
        <div className="flex justify-center items-center h-full">
          <ConnectInstagram />
        </div>
      )}
    </div>
  );
}
