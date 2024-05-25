'use client';

import { signIn, signOut, useSession } from 'next-auth/react';
import { Button } from './ui/button';
import { ModeToggle } from './mode-toggle';
import Link from 'next/link';
import { toast } from './ui/use-toast';

export default function AppBar() {
  const { data: session } = useSession();

  return (
    <div className="flex gap-5 w-screen justify-between">
      <Button
        variant="link"
        className="ml-4"
      >
        <Link href="/">Home</Link>
      </Button>
      <div className="flex gap-2 items-center">
        <p>{session?.user?.email}</p>
        {session?.user ? (
          <>
            <p className="text-sky-600">{session.user.name}</p>
            <Button
              variant="outline"
              className="text-red-300"
              onClick={() => {
                signOut({redirect: false});
                toast({ description: 'Sign out' });
              }}
            >
              Sign Out
            </Button>
          </>
        ) : (
          <Button
            variant="outline"
            className="text-green-300"
            onClick={() => signIn()}
          >
            Sign In
          </Button>
        )}
        <ModeToggle />
      </div>
    </div>
  );
}
